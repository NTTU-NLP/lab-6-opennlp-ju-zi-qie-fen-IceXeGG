using java.io;
using opennlp.tools.tokenize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("example.txt"))
            {
                string[] files = Directory.GetFiles(@"..\..\..\Dataset\", "*.html");
                foreach (var file in files)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (sr.Peek() != -1)
                        {
                            string line = sr.ReadLine();
                            InputStream modelIn = new FileInputStream(@"..\..\..\en-token.bin");
                            string[] tokens;

                            TokenizerModel model = new TokenizerModel(modelIn);
                            TokenizerME Tokenizer = new TokenizerME(model);

                            tokens = Tokenizer.tokenize(line);
                            for (int i = 0;i<tokens.Length;i++)
                            {
                                sw.WriteLine(tokens[i]+" ");
                            }

                            
                        }
                        
                    }
                }
            }
        }
    }
}
