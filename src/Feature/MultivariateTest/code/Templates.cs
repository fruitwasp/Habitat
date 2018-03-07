namespace Sitecore.Feature.MultivariateTest
{
    using Sitecore.Data;

    public struct Templates
    {
        public struct MultivariateTest
        {
            public static readonly ID ID = new ID("{2F75C8AF-35FC-4A88-B585-7595203F442C}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{BD9ECD4A-C0B0-4233-A3CD-D995519AC87B}");
                public const string Title_FieldName = "MultivariateTestTitle";
            }
        }

        public struct MultivariateTestFolder
        {
            public static readonly ID ID = new ID("{2F75C8AF-35FC-4A88-B585-7595203F442C}");
        }
    }
}