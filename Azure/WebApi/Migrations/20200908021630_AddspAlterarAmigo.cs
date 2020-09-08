using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class AddspAlterarAmigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[AdicionarAmigo]
	                @nome nvarchar(max),
	                @sobrenome nvarchar(max),
	                @email nvarchar(max),
	                @telefone int,
	                @nascimento Datetime2(7)
                AS
                   UPDATE AMIGO SET 
	                NOME = @nome, SOBRENOME = @sobrenome, EMAIL = @email, TELEFONE = @telefone, NASCIMENTO = @nascimento WHERE ID = @id
                RETURN 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[AdicionarAmigo]
	                @nome nvarchar(max),
	                @sobrenome nvarchar(max),
	                @email nvarchar(max),
	                @telefone int,
	                @nascimento Datetime2(7)
                AS
                   UPDATE AMIGO SET 
	                NOME = @nome, SOBRENOME = @sobrenome, EMAIL = @email, TELEFONE = @telefone, NASCIMENTO = @nascimento WHERE ID = @id
                RETURN 0");
        }
    }
    }
}
