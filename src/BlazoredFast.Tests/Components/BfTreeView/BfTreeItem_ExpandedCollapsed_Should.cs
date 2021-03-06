namespace BlazoredFast.Tests.Components.BfTreeView
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp.Dom;

    using Bunit;

    using FluentAssertions;

    using SayusiAndo.Carbon.BlazoredFast.Components;
    using SayusiAndo.Carbon.BlazoredFast.Components.TreeView;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ExcludeFromCodeCoverage]
    public class BfTreeItem_ExpandedCollapsed_Should : TestContext
    {
        [Fact]
        public async Task BeClosedByDefault()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>()
            );

            // Assert
            INamedNodeMap attrs = cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem).Attributes;
            attrs.GetNamedItem(BfComponentApis.BfTreeItem.Attributes.Expanded)
                .Should().BeNull();
        }

        [Fact]
        public async Task BeClosedWhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa => { pa.Add(b => b.Expanded, false); })
            );

            // Assert
            INamedNodeMap attrs = cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem).Attributes;
            attrs.GetNamedItem(BfComponentApis.BfTreeItem.Attributes.Expanded)
                .Should().BeNull();
        }

        [Fact]
        public async Task BeOpenWhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa => { pa.Add(b => b.Expanded, true); })
            );

            // Assert
            INamedNodeMap attrs = cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem).Attributes;
            attrs.GetNamedItem(BfComponentApis.BfTreeItem.Attributes.Expanded)
                .Should().NotBeNull();
        }
    }
}