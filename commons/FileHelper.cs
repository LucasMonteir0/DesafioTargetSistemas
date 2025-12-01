using System.Text.Json;

namespace DesafioTargetSistemas.commons

{
    public class FileHelper
    {

        static private string? LerArquivo(String path)
        {
      
            try
        {
            Console.WriteLine("Lendo dados, aguarde um momento");
            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), path));
        }
        catch (FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERRO: Arquivo '{path}' não encontrado."); 
            Console.WriteLine("Por favor, crie o arquivo dados.json na pasta de execução do programa com o conteúdo JSON fornecido.");
            Console.ResetColor();
            return null;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ocorreu um erro ao ler o arquivo '{path}': {ex.Message}");
            Console.ResetColor();
            return null;
        }
        }

        static public TValue? ConverterParaJson<TValue>(String path)
        {
     
                var content = LerArquivo(path);

                if(content == null)
                {
                    ArgumentNullException.ThrowIfNull(content);
                }
            
                return JsonSerializer.Deserialize<TValue>(content);

        }
    
    }
}