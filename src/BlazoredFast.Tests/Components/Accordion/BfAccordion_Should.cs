namespace BlazoredFast.Tests.Components.Accordion
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using AngleSharp.Dom;

    using Bunit;

    using FluentAssertions;

    using SayusiAndo.Carbon.BlazoredFast;
    using SayusiAndo.Carbon.BlazoredFast.Components;
    using SayusiAndo.Carbon.BlazoredFast.Components.Accordion;

    using Xunit;

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ExcludeFromCodeCoverage]
    public class BfAccordion_Should : TestContext
    {
        [Fact]
        public async Task Have_ExpandMode_Attribute_SetToMulti_ByDefault()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>();

            // Asset
            IAttr attr = cut.Find(FastHtmlElements.FastAccordion)
                .Attributes
                .GetNamedItem(FastHtmlElements.FastAccordionAttributes.ExpandMode);

            attr.Should().NotBeNull();
        }

        [Fact]
        public async Task Have_ExpandMode_Attribute_SetToMulti_WhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.Add(pp => pp.ExpandMode, BfComponentApis.BfAccordion.ExpandModeValues.Multi));

            // Asset
            IAttr attr = cut.Find(FastHtmlElements.FastAccordion)
                .Attributes
                .GetNamedItem(FastHtmlElements.FastAccordionAttributes.ExpandMode);

            attr.Should().NotBeNull();
        }

        [Fact]
        public async Task Have_ExpandMode_Attribute_SetToSingle_WhenConfiguredSo()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                p => p.Add(pp => pp.ExpandMode, BfComponentApis.BfAccordion.ExpandModeValues.Single));

            // Asset
            IAttr attr = cut.Find(FastHtmlElements.FastAccordion)
                .Attributes
                .GetNamedItem(FastHtmlElements.FastAccordionAttributes.ExpandMode);

            attr.Should().NotBeNull();
        }

        [Fact]
        public async Task HaveNoCssClasses()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>();

            // Assert
            cut.Find(FastHtmlElements.FastAccordion)
                .ClassList.Length
                .Should()
                .Be(0);
        }

        [Fact]
        public async Task SplatUnknownParameters()
        {
            // Arrange
            IRenderedComponent<BfAccordion> cut = RenderComponent<BfAccordion>(
                ("custom", "value"));

            // Assert
            IAttr attr = cut.Find(FastHtmlElements.FastAccordion)
                .Attributes
                .GetNamedItem("custom");
            attr.Should().NotBeNull();
            attr.Value.Should().Be("value");
        }
    }
}