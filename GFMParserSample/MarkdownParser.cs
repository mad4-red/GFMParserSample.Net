using System;
using JavaScriptEngineSwitcher.Core;

namespace GFMParserSample
{
    public class MarkdownParser : IDisposable
    {
        private IJsEngine _jsEngine;
        private bool _disposed;

        public MarkdownParser(IJsEngine jsEngine)
        {
            if (jsEngine == null) throw new ArgumentNullException("jsEngine");

            var type = GetType();

            _jsEngine = jsEngine;
            _jsEngine.ExecuteResource("GFMParserSample.Scripts.marked.js", type);
            _jsEngine.ExecuteResource("GFMParserSample.Scripts.highlight.pack.js", type);
        }

        public string Transform(string markdown)
        {
            _jsEngine.Evaluate(@"marked.setOptions({
  highlight: function (code) {
    return hljs.highlightAuto(code).value;
  }
});"
                );

            return _jsEngine.CallFunction<string>("marked", markdown);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            if (_jsEngine == null) return;
            _jsEngine.Dispose();
            _jsEngine = null;
        }
    }
}
