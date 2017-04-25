using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Dominio.Repositorios;
using System.Web.Script.Serialization;
using System.Linq.Expressions;
using System.Collections.Specialized;
using System.Collections;
using DDDExample.Nucleo.Infraestrutura.Excecoes;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;


namespace DDDExample.Nucleo.Dominio.Servicos.Impl
{
    public abstract class ServicoCRUD<TEntidade> : IServicoCRUD<TEntidade>
        where TEntidade : Entidade
    {

        private readonly IRepositorio<TEntidade> Repositorio;
        protected List<string> mensagensValidacao = new List<string>();
        JavaScriptSerializer jss = new JavaScriptSerializer();

        public ServicoCRUD(IRepositorio<TEntidade> repositorio)
        {
            Repositorio = repositorio;
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return Repositorio.ObterPorId(id);
        }

        public virtual IEnumerable<TEntidade> Listar()
        {
            return Repositorio.Listar();
        }

        public virtual IEnumerable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] incluirPropriedades)
        {
            return Repositorio.Listar(incluirPropriedades);
        }

        public virtual void Excluir(int id)
        {
            var entidade = Repositorio.ObterPorId(id);
            Repositorio.Apagar(entidade);
        }

        public virtual void Salvar(TEntidade entidade)
        {
            Repositorio.Salvar(entidade);
        }

        public IEnumerable<TEntidade> Pesquisar(System.Linq.Expressions.Expression<System.Func<TEntidade, bool>> where, int limit)
        {
            return Repositorio.Procurar(where, limit);
        }

        public IEnumerable<TEntidade> Pesquisar(System.Linq.Expressions.Expression<System.Func<TEntidade, bool>> where, int limit, int offset)
        {
            return Repositorio.Procurar(where, limit, offset);
        }

        public IEnumerable<TEntidade> Pesquisar(System.Linq.Expressions.Expression<System.Func<TEntidade, bool>> where)
        {
            return Repositorio.Procurar(where);
        }

        public string GerarMD5(string valor = null)
        {
            if (valor == null) return null; 
            MD5 md5Hasher = MD5.Create();

            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(valor));

            StringBuilder strBuilder = new StringBuilder();

            for (int i=0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
