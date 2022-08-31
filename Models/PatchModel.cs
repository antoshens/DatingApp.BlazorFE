namespace DatingApp.FrontEnd.Models
{
    public class SinglePropertyPatchReplace
    {
        public string Op { get; private set; } = "replace";
        public dynamic Value { get; set; }
        public string Path { get; set; }
    }

    public class PatchModel<T> where T : class
    {
        public List<SinglePropertyPatchReplace> ReplaceProperties { get; private set; }

        public PatchModel(T model)
        {
            ReplaceProperties = new List<SinglePropertyPatchReplace>();

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                ReplaceProperties.Add(new SinglePropertyPatchReplace
                {
                    Value = property.GetValue(model),
                    Path = $"/{property.Name}"
                });
            }
        }
    }
}
