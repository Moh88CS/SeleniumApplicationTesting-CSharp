namespace NUnitSeleniumTest.Entities;

public class SearchResultItem
{
    public string Title { get; }

    public string HrefAttributeValue { get; }

    public SearchResultItem(string title, string hrefAttribte)
    {
        Title = title;
        HrefAttributeValue = hrefAttribte;
    }

    public override bool Equals(object obj) => obj is SearchResultItem item && // how to override and is keyword casting
               Title == item.Title &&
               HrefAttributeValue == item.HrefAttributeValue;

    public override int GetHashCode() => HashCode.Combine(Title, HrefAttributeValue); // important to hash based collections like dict, so they have same key  for the item

    public override string ToString() => $"{nameof(SearchResultItem)}:{{\n" + // for readable error messages
            $"{nameof(Title)}={Title},\n" +
            $"{nameof(HrefAttributeValue)}={HrefAttributeValue}\n}}";
}
