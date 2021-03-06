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
    public class BfAccordionItemContent_Should : TestContext
    {
        [Fact]
        public async Task SplatUnknownParameters()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>(
                    pp => pp.AddChildContent<BfAccordionItemContent>(
                        ppp => { ppp.AddUnmatched("custom", "value"); }
                    )
                )
            );

            // Assert
            IAttr attr = cut.Find($"{FastHtmlElements.FastAccordion}>" +
                                  $"{FastHtmlElements.FastAccordionItem}>" +
                                  $"div")
                .Attributes
                .GetNamedItem("custom");
            attr.Value.Should().Be("value");
        }

        [Fact]
        public async Task WrapContent()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.AddChildContent<BfAccordionItem>(
                    pp => pp.AddChildContent<BfAccordionItemContent>(
                        ppp => ppp.AddChildContent("content")
                    )
                )
            );

            // Assert
            cut.Find($"{FastHtmlElements.FastAccordion}>" +
                     $"{FastHtmlElements.FastAccordionItem}>" +
                     $"div")
                .InnerHtml
                .Contains("content")
                .Should()
                .BeTrue();
        }
    }
}