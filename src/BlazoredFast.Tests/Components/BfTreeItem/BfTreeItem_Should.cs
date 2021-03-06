namespace BlazoredFast.Tests.Components.BfTreeItem
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Bunit;

    using FluentAssertions;

    using SayusiAndo.Carbon.BlazoredFast.Components;
    using SayusiAndo.Carbon.BlazoredFast.Components.TreeView;

    using Xunit;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BfTreeItem_Should : TestContext
    {
        [Fact]
        public async Task Render_FastTreeItem_Tag()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>()
            );

            // Assert
            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
                .Should()
                .NotBeNull();
        }

        [Fact]
        public async Task Splat_Attribute()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa => pa.AddUnmatched("custom", "value")
                ));

            // Assert
            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
                .Attributes
                .GetNamedItem("custom")
                .Value
                .Should()
                .Be("value");
        }

        [Fact]
        public async Task Splat_Attributes()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa =>
                    {
                        pa.AddUnmatched("custom", "value");
                        pa.AddUnmatched("custom2", "value2");
                    }));

            // Assert
            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
                .Attributes
                .GetNamedItem("custom")
                .Value
                .Should()
                .Be("value");

            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
                .Attributes
                .GetNamedItem("custom2")
                .Value
                .Should()
                .Be("value2");
        }

        [Fact]
        public async Task RenderChildContent()
        {
            // Arrange
            IRenderedComponent<BfTreeView> cut = RenderComponent<BfTreeView>(
                p => p.AddChildContent<BfTreeItem>(
                    pa => { pa.AddChildContent<BfTreeItem>(); }));

            // Assert
            cut.Find(BfComponentApis.BfTreeItem.Html.BfTreeItem)
                .ToMarkup()
                .Contains(BfComponentApis.BfTreeItem.Html.BfTreeItem)
                .Should()
                .BeTrue();
        }
    }
}