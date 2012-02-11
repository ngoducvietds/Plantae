using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plantae.Core.Repositories;

namespace Plantae.Core.Services
{
    public class UserServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        public void CreateCategoriasBasicas(string username)
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository(new ContextFactory());

            string[] categorias = new string[] {"Diversos", "Alimentação", "Energia Elétrica", "Telefonia"};

            foreach(string categoria in categorias)
                categoriaRepository.InsertOnSubmit(new CATEGORIA() { Nome = categoria, Owner = username });

            categoriaRepository.Save();
        }
    }
}
