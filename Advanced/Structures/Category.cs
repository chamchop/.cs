public struct Category
{
    private int _categoryId;
    private string _categoryName;

    // must initialise all fields
    public Category(int categoryId, string categoryName)
    {
        _categoryId = categoryId;
        _categoryName = categoryName;
    }

    public int CategoryId
    {
        set
        {
            if (value >= 1 && value <= 100)
            {
                _categoryId = value;
            }
        }
        get
        {
            return _categoryId;
        }
    }

    public string CategoryName
    {
        set
        {
            if (value.Length <= 40)
            {
                _categoryName = value;
            }
        }
        get
        {
            return _categoryName;
        }
    }

    public int GetCategoryNameLength()
    {
        return this._categoryName.Length;
    }

    public override string ToString() // override System.Object
    {
        return "ID: " + this.CategoryName;
    }

}