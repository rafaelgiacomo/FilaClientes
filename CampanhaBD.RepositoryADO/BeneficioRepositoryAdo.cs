using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class BeneficioRepositoryAdo : IRepository<BeneficioModel>
    {
        private Context _context;

        public BeneficioRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(BeneficioModel entidade)
        {
            
        }

        public void Alterar(BeneficioModel entidade)
        {
            
        }

        public void Excluir(BeneficioModel entidade)
        {
            
        }

        public List<BeneficioModel> ListarTodos()
        {
            return new List<BeneficioModel>();
        }

        public BeneficioModel ListarPorId(BeneficioModel entidade)
        {
            return new BeneficioModel();
        }

        private List<BeneficioModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<BeneficioModel>();
            while (reader.Read())
            {
                var temObjeto = new BeneficioModel()
                {
                    Numero = int.Parse(reader["numero"].ToString()),
                    IdCliente = int.Parse(reader["pessoa_id"].ToString()),
                    Salario = float.Parse(reader["salario"].ToString()),
                    DataCompetencia = DateTime.Parse(reader["dataCompetencia"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }

    }
}
