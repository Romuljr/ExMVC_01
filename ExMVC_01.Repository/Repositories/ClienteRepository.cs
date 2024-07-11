using Dapper;
using ExMVC_01.Repository.Contracts;
using ExMVC_01.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMVC_01.Repository.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //Atributo
        private readonly string connectionString;


        //Constructor com entrada de argumentos ( passagem de parametros ) 
        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public void Inserir(Cliente obj)
        {
            //Abrindo uma conexão com o banco de dados do SqlServer
            using (var connection = new SqlConnection(connectionString))
            {
                //Executando a stored procedure
                connection.Execute(
                    "SP_INCLUIR_CLIENTE", //Nome da SP 
                    new //Passagem dos parametros da procedure
                    {
                        P_NOME = obj.Nome,
                        P_EMAIL = obj.Email,
                        P_CPF = obj.Cpf,
                        P_DATANASCIMENTO = obj.DataNascimento,
                        P_SEXO = obj.Sexo
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Alterar(Cliente obj)
        {
            //Abrindo uma conexão com o banco de dados do SqlServer
            using (var connection = new SqlConnection(connectionString))
            {
                //Executando a stored procedure
                connection.Execute(
                    "SP_ALTERAR_CLIENTE", //Nome da StoredProcedure 
                    new //Passagem dos parametros da procedure
                    {
                        P_ID = obj.Id,
                        P_NOME = obj.Nome,
                        P_DATANASCIMENTO = obj.DataNascimento,
                        P_SEXO = obj.Sexo
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Exluir(Cliente obj)
        {
            //Abrindo uma conexão com o banco de dados do SqlServer
            using (var connection = new SqlConnection(connectionString))
            {
                //Executando a stored procedure
                connection.Execute(
                    "SP_EXCLUIR_CLIENTE", //Nome da StoredProcedure 
                    new //Passagem dos parametros da procedure
                    {
                        P_ID = obj.Id,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Cliente> Consultar()
        {
            //escrevendo a query SQL
            var query = @"
                 SELECT
                     ID AS ID,
                     NOME,
                     EMAIL,
                     CPF,
                     DATANASCIMENTO,
                     SEXO,
                     DATACRIACAO,
                     DATAALTERACAO,
                     ATIVO AS STATUS
                 FROM CLIENTE 
                 ORDER BY NOME ASC";

            //Conectando  com o banco de dados do SqlServer a query...
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cliente>(query).ToList();
            }
        }

        public List<Cliente> ConsultarPorNome(string nome)
        {
            //escrevendo a query SQL
            var query = @"
                 SELECT
                     ID AS ID,
                     NOME,
                     EMAIL,
                     CPF,
                     DATANASCIMENTO,
                     SEXO,
                     DATACRIACAO,
                     DATAALTERACAO,
                     ATIVO AS STATUS
                 FROM CLIENTE 
                 WHERE NOME LIKE @P_NOME
                 ORDER BY NOME ASC";


            //Conectando  com o banco de dados do SqlServer a query...
            using (var connection = new SqlConnection(connectionString))
            {
                return connection
                .Query<Cliente>(query, new
                {
                    P_NOME = $"%{nome}%"
                })
                .ToList();
            }
        }


        public Cliente ObterPorCpf(string cpf)
        {
            //escrevendo a query SQL
            var query = @"
             SELECT
             ID AS ID,
             NOME,
             EMAIL,
             CPF,
             DATANASCIMENTO,
             SEXO,
             DATACRIACAO,
             DATAALTERACAO,
             ATIVO AS STATUS
             FROM CLIENTE 
             WHERE CPF = @P_CPF";
            //conectando no banco de dados e executando a query..
            using (var connection = new SqlConnection(connectionString))
            {
                return connection
                .Query<Cliente>(query, new
                {
                    P_CPF = cpf
                })
               .FirstOrDefault();
            }
        }


        public Cliente ObterPorEmail(string email)
        {
            //escrevendo a query SQL
            var query = @"
             SELECT
             ID AS ID,
             NOME,
             EMAIL,
             CPF,
             DATANASCIMENTO,
             SEXO,
             DATACRIACAO,
             DATAALTERACAO,
             ATIVO AS STATUS
             FROM CLIENTE 
             WHERE EMAIL = @P_EMAIL";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection
                .Query<Cliente>(query, new
                {
                    P_EMAIL = email
                })
               .FirstOrDefault();
            }
        }


        public Cliente ObterPorId(Guid id)
        {
            //escrevendo a query SQL
            var query = @"
             SELECT
             ID AS ID,
             NOME,
             EMAIL,
             CPF,
             DATANASCIMENTO,
             SEXO,
             DATACRIACAO,
             DATAALTERACAO,
             ATIVO AS STATUS
             FROM CLIENTE 
             WHERE ID = @P_ID";
            //conectando no banco de dados e executando a query..
            using (var connection = new SqlConnection(connectionString))
            {
                return connection
                .Query<Cliente>(query, new
                {
                    P_ID = id
                })
                .FirstOrDefault();
            }
        }
    }
}