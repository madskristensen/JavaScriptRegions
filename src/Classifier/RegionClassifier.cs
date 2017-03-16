using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Language.StandardClassification;

namespace JavaScriptRegions
{
    internal class RegionClassifier : IClassifier
    {
        private static Regex _regex = new Regex(@"^\s*//\s*(?<region>#(end)?region.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private IClassificationType _formatDefinition;

        public RegionClassifier(IClassificationTypeRegistryService registry)
        {
            _formatDefinition = registry.GetClassificationType(PredefinedClassificationTypeNames.ExcludedCode);
        }

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            IList<ClassificationSpan> list = new List<ClassificationSpan>();
            string text = span.GetText();

            if (span.IsEmpty || string.IsNullOrWhiteSpace(text))
                return list;

            Match match = _regex.Match(text);

            if (match.Success)
            {
                var group = match.Groups["region"];
                var result = new SnapshotSpan(span.Snapshot, span.Start + group.Index, group.Length);
                list.Add(new ClassificationSpan(result, _formatDefinition));
            }

            return list;
        }

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged
        {
            add { }
            remove { }
        }
    }
}