﻿using eventplus_codefirst.Contexts;
using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;
using eventplus_codefirst.Utils;

namespace eventplus_codefirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;
        public UsuarioRepository()
        {
            _eventContext = new();
        }

        public Usuario BuscarIdEAtualizar(Guid id, Usuario usuario)
        {
            try
            {
                Usuario editado = BuscarPorId(id);
                if (editado != null)
                {
                    editado.Nome = usuario.Nome;
                    editado.Email = usuario.Email;
                    editado.Senha = Criptografia.GerarHash(usuario.Senha);
                    _eventContext.Update(editado);
                    _eventContext.SaveChanges();
                    return editado;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario user = _eventContext.Usuario.First(x => x.Email == email);
                if (user != null && Criptografia.CompararHash(senha, user.Senha))
                {
                    return user;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario? usuarioBuscado = _eventContext.Usuario.Select(x => new Usuario
                {
                    IdUsuario = x.IdUsuario,
                    Nome = x.Nome,
                    Email = x.Email,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = x.IdTipoUsuario,
                        Titulo = x.TipoUsuario!.Titulo
                    }
                }).FirstOrDefault(x => x.IdUsuario == id);
                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);
                _eventContext.Usuario.Add(usuario);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                _eventContext.Usuario.Remove(_eventContext.Usuario.First(x => x.IdUsuario == id));
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> ListarTodos()
        {
            return _eventContext.Usuario.ToList();
        }
    }
}
