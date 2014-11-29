using System;
using JavaScriptEngineSwitcher.V8;

namespace GFMParserSample
{
    class Program
    {
        static void Main()
        {
            const string markdown = @"
```cs
public class Foo
{
    public string Bar { get; set; }

    public string Buz()
    {
        return Bar;
    }
}
```
";

            var parser = new MarkdownParser(new V8JsEngine());

            var html = parser.Transform(markdown);

            Console.WriteLine(html);
            Console.ReadLine();
        }
    }
}
