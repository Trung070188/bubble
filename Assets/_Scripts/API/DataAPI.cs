using System;
using System.Collections.Generic;

[Serializable]
public class DataAPI<T>
{
    public T data;
    public bool isSuccess;
    public string message;
}

[Serializable]
public class DataListAPI<T>
{
    public T data;
    public bool success;
    public string message;
}
