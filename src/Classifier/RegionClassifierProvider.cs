using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace JavaScriptRegions
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("JavaScript")]
    [ContentType("TypeScript")]
    [ContentType("node.js")]
    [Order(After = "Default")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    public class RegionClassifierProvider : IClassifierProvider
    {
        [Import]
        public IClassificationTypeRegistryService Registry { get; set; }

        public IClassifier GetClassifier(ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new RegionClassifier(Registry));
        }
    }
}