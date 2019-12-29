# DumpSharp

Small library which helps to dump objects.

```
Foo.Property = 17
Foo.String = Test
Foo.List[0] = 1
Foo.List[1] = 2
Foo.List[2] = 3
Foo.Readonly = 1
Foo.BarBar.Int = 17
Foo.BarBar.Bars = NULL
```

```csharp
object o = new object(),
o.Dump(); //Prints the object to the console
string dump = p.ToDumpString(); // Returns the dumped string
```