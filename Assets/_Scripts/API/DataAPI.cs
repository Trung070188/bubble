using System;
using System.Collections.Generic;

[Serializable]
public class DataAPI<T>
{
    public bool success;
    public string message;
    public int code;
    public T data;
}

[Serializable]
public class DataListAPI<T>
{
    public bool success;
    public string message;
    public int code;
    public List<T> data;
}
