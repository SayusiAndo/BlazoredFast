namespace BlazoredFast.Tests.Components.Accordion
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using AngleSharp.Dom;

    using Bunit;

    using FluentAssertions;

    using SayusiAndo.Carbon.BlazoredFast;
    using SayusiAndo.Carbon.BlazoredFast.Components.Accordion;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ExcludeFromCodeCoverage]
    public class BfAccordionItem_Should : TestContext
    {
        [Fact]
        public async Task BeClosed_ByDefault()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>());

            // Assert
            cut.Find($"{FastHtmlElements.FastAccordion}>{FastHtmlElements.FastAccordionItem}")
                .ClassList.Length.Should().Be(0);
        }

        [Fact]
        public async Task BeOpened_WhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>(pp => pp.Add(
                    ppp => ppp.IsExpanded, true)));

            // Assert
            IAttr attr = cut.Find($"{FastHtmlElements.FastAccordion}>{FastHtmlElements.FastAccordionItem}")
                .Attributes
                .GetNamedItem("expanded");
            attr.Should().NotBeNull();
        }

        [Fact]
        public async Task Splat_UnknownParameters()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>(
                    ppp => ppp.AddUnmatched("custom", "value")
                ));

            // Assert
            IAttr attr = cut.Find($"{FastHtmlElements.FastAccordion}>{FastHtmlElements.FastAccordionItem}")
                .Attributes
                .GetNamedItem("custom");
            attr.Should().NotBeNull();
            attr.Value.Should().Be("value");
        }
    }
}