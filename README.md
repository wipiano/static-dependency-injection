# StaticDependencyInjection

これは ASP.NET Core の DI をより簡単にするためのライブラリです．
（TODO: 英語への翻訳）

## Usage

DI に登録したい型に Attribute をつけます．

```csharp
[SingletonService]
public class FooServiceImpl : IFooService
{
    // ...
}

public interface IBarService
{
    // ...
}

[ScopedServiceAs(typeof(IBarService))]
public class DefaultBarService : IBarService
{
    // ...
}

[TransientServiceWith(typeof(FooServiceImpl))]
public interface IFooService
{
    // ...
}
```

このあと， `AddStaticServices` 拡張メソッドを呼び出します．

```csharp
serviceCollection.AddStaticServices(Assembly.GetAssembly(typeof(IFooService)));
```

この呼び出しによって，下記と等価な処理が実行されます．

```csharp
serviceCollection.TryAddSingleton<FooServiceImpl>();
serviceCollection.TryAddScoped<IBarService, DefaultBarService>();
serviceCollection.TryAddTransient<IFooService, FooServiceImpl>();
```
