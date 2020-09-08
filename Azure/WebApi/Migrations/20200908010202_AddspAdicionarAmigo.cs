using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class AddspAdicionarAmigo : Migration
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
                    INSERT INTO [dbo].[Amigo] ([Id], [Nome], [Sobrenome], [email], [telefone], [nascimento]) 
	                VALUES (@nome, @sobrenome, @email, @telefone, @nascimento)
                RETURN 0");
                        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[AdicionarAmigo]
	               ");
        }
    }
}
