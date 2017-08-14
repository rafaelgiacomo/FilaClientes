using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampanhaBD.Model;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class ImportacaoRepositoryAdo : IRepository<ImportacaoModel>
    {
        private Context _context;

        public ImportacaoRepositoryAdo(Context context)
        {
            _context = context;
        }

        #region Metodos publicos
        public void Inserir(ImportacaoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ImportacaoModel.COLUMN_USUARIO_ID, ImportacaoModel.COLUMN_NOME,
                    ImportacaoModel.COLUMN_TERMINADO, ImportacaoModel.COLUMN_NUM_IMPORTADOS,
                    ImportacaoModel.COLUMN_NUM_ATUALIZADOS, ImportacaoModel.COLUMN_CAMINHO_ARQUIVO
                };

                object[] values =
                {
                    entidade.UsuarioId, entidade.Nome, entidade.Terminado, entidade.NumImportados,
                    entidade.NumAtualizados, entidade.CaminhoArquivo
                };

                var reader = _context.ExecuteProcedureWithReturn(
                    ImportacaoModel.PROCEDURE_INSERT, parameters, values);

                if (reader.Read())
                {
                    var ultimoId = reader[0].ToString();

                    if (!String.IsNullOrEmpty(ultimoId))
                        entidade.Id = Convert.ToInt32(ultimoId);
                }

                reader.Close();
            }
            catch
            {
                throw;
            }
        }

        public void SalvarCaminho(ImportacaoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ImportacaoModel.COLUMN_ID, ImportacaoModel.COLUMN_CAMINHO_ARQUIVO
                };

                object[] values =
                {
                    entidade.Id, entidade.CaminhoArquivo
                };

                _context.ExecuteProcedureNoReturn(
                    ImportacaoModel.PROCEDURE_UPDATE_CAMINHO, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void SalvarNumImportados(ImportacaoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ImportacaoModel.COLUMN_ID, ImportacaoModel.COLUMN_NUM_IMPORTADOS
                };

                object[] values =
                {
                    entidade.Id, entidade.NumImportados
                };

                _context.ExecuteProcedureNoReturn(
                    ImportacaoModel.PROCEDURE_UPDATE_NUM_IMPORTADOS, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void Alterar(ImportacaoModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Importacao SET ";
            //strQuery += string.Format(" nome = '{0}', ", entidade.Nome);
            //strQuery += string.Format(" data = '{0}', ", entidade.Data);
            //strQuery += string.Format(" terminado = '{0}', ", entidade.Terminado);
            //strQuery += string.Format(" numImportados = '{0}', ", entidade.NumImportados);
            //strQuery += string.Format(" atualizados = '{0}' ", entidade.NumAtualizados);
            //strQuery += string.Format(" WHERE imp_id = '{0}' AND usuario_id = '{1}' ", entidade.Id, entidade.UsuarioId);
            //_context.ExecutaComando(strQuery);
        }

        public void Excluir(ImportacaoModel entidade)
        {
            //var strQuery = string.Format(" DELETE FROM Importacao WHERE imp_id = '{0}' AND usuario_id = '{1}' ", entidade.Id, entidade.UsuarioId
            //    );
            //_context.ExecutaComando(strQuery);
        }

        public List<ImportacaoModel> ListarTodos()
        {
            try
            {
                List<ImportacaoModel> lista = new List<ImportacaoModel>();
                SqlDataReader reader = null;

                string[] parameters = { };
                object[] values = { };

                reader = _context.ExecuteProcedureWithReturn(
                    ImportacaoModel.PROCEDURE_SELECT_ALL, parameters, values);

                while (reader.Read())
                {
                    var entidade = TransformaReaderEmObjeto(reader);

                    lista.Add(entidade);
                }

                reader.Close();

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public void Terminar(ImportacaoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ImportacaoModel.COLUMN_ID
                };

                object[] values =
                {
                    entidade.Id
                };

                var reader = _context.ExecuteProcedureWithReturn(
                    ImportacaoModel.PROCEDURE_TERMINAR, parameters, values);

                if (reader.Read())
                {
                    var ultimoId = reader[0].ToString();

                    if (!String.IsNullOrEmpty(ultimoId))
                        entidade.Id = Convert.ToInt32(ultimoId);
                }

                reader.Close();
            }
            catch
            {
                throw;
            }
        }

        public ImportacaoModel ListarPorId(ImportacaoModel entidade)
        {
            try
            {
                SqlDataReader reader = null;
                var retorno = new ImportacaoModel();

                string[] parameters = { ImportacaoModel.COLUMN_ID };
                object[] values = { entidade.Id };

                reader = _context.ExecuteProcedureWithReturn(
                    ImportacaoModel.PROCEDURE_SELECT_BY_ID, parameters, values);

                if(reader.Read())
                {
                    retorno = TransformaReaderEmObjeto(reader);
                }

                reader.Close();

                return retorno;
            }
            catch
            {
                throw;
            }
        }

        public ImportacaoModel ListarPorNome(ImportacaoModel entidade)
        {
            try
            {
                SqlDataReader reader = null;
                ImportacaoModel retorno = null;

                string[] parameters = { ImportacaoModel.COLUMN_NOME };
                object[] values = { entidade.Nome };

                reader = _context.ExecuteProcedureWithReturn(
                    ImportacaoModel.PROCEDURE_SELECT_BY_NOME, parameters, values);

                if (reader.Read())
                {
                    retorno = TransformaReaderEmObjeto(reader);
                }

                reader.Close();

                return retorno;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Metodos Privados
        private ImportacaoModel TransformaReaderEmObjeto(SqlDataReader reader)
        {
            try
            {
                var temObjeto = new ImportacaoModel();
                temObjeto.Id = Convert.ToInt32(reader[ImportacaoModel.COLUMN_ID].ToString());
                temObjeto.UsuarioId = Convert.ToInt32(reader[ImportacaoModel.COLUMN_USUARIO_ID].ToString());
                temObjeto.Nome = reader[ImportacaoModel.COLUMN_NOME].ToString();
                temObjeto.Data = Convert.ToDateTime(reader[ImportacaoModel.COLUMN_DATA].ToString());
                temObjeto.NumImportados = Convert.ToInt32(reader[ImportacaoModel.COLUMN_NUM_IMPORTADOS].ToString());
                temObjeto.NumAtualizados = Convert.ToInt32(reader[ImportacaoModel.COLUMN_NUM_ATUALIZADOS].ToString());
                temObjeto.Terminado = Convert.ToBoolean(reader[ImportacaoModel.COLUMN_TERMINADO].ToString());
                temObjeto.CaminhoArquivo = reader[ImportacaoModel.COLUMN_CAMINHO_ARQUIVO].ToString();

                return temObjeto;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
