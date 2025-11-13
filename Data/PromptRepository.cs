using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;
using Microsoft.Extensions.Configuration;
using PromptApi.Models;

namespace PromptApi.Data
{
    public class PromptRepository
    {
        private readonly string _connectionString;

        // Construtor para injetar a Configuration e ler a string de conexão
        public PromptRepository(IConfiguration configuration)
        {
            // Lê a string de conexão do appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        // Cria uma nova conexão com o banco SQLite
        private IDbConnection CreateConnection() =>
            new SqliteConnection(_connectionString);

        // Método para buscar todos os prompts
        public async Task<IEnumerable<Prompt>> GetAllAsync()
        {
            using var conn = CreateConnection();
            var sql = "SELECT * FROM Prompts";
            return await conn.QueryAsync<Prompt>(sql);
        }

        // Método para buscar um prompt pelo ID
        public async Task<Prompt?> GetByIdAsync(int id)
        {
            using var conn = CreateConnection();
            var sql = "SELECT * FROM Prompts WHERE Id = @Id";
            return await conn.QuerySingleOrDefaultAsync<Prompt>(sql, new { Id = id });
        }

        // Método para inserir um novo prompt
        public async Task<int> InsertAsync(Prompt prompt)
        {
            using var conn = CreateConnection();
            // "SELECT last_insert_rowid()" é específico do SQLite para retornar o ID inserido
            var sql = "INSERT INTO Prompts (Text) VALUES (@Text); SELECT last_insert_rowid();";
            return await conn.ExecuteScalarAsync<int>(sql, prompt);
        }

        // Método para atualizar um prompt existente
        public async Task<int> UpdateAsync(Prompt prompt)
        {
            using var conn = CreateConnection();
            var sql = "UPDATE Prompts SET Text = @Text WHERE Id = @Id";
            return await conn.ExecuteAsync(sql, prompt);
        }

        // Método para deletar um prompt pelo ID
        public async Task<int> DeleteAsync(int id)
        {
            using var conn = CreateConnection();
            var sql = "DELETE FROM Prompts WHERE Id = @Id";
            return await conn.ExecuteAsync(sql, new { Id = id });
        }
    }
}