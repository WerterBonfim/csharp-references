using Dapper;
using Microsoft.Data.SqlClient;

using var connection = new SqlConnection("Server=localhost,1433;Database=LojaOnline;User Id=sa;Password=!123Senha;Encrypt=false");


//connection.QuerySingle("SELECT @@VERSION GO; SELECT GETDATE()");
var query = $@"  begin
                            waitfor delay '{TimeSpan.FromSeconds(2)}'
                            select 1 as qtd, 10 as soma
                        end";
var resultaod = connection.QuerySingle<(int, double)>(query);


Console.ReadKey();