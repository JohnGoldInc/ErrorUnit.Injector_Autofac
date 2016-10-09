# ErrorUnit.Injector_Autofac
Compatibility library for ErrorUnit to work with Autofac Dependency Injector.

At the start up of your application; You will need to set up the Injector with ErrorUnit;
Then add `.EnableErrorUnitInterceptor()` after each type you register.
i.e.

`
ErrorUnitCentral._Injector = new ErrorUnitInjector();
var builder = ErrorUnitCentral._LinkInjector(new ContainerBuilder());
builder.RegisterType<SomeType>()
       .As<ISomeInterface>()
       .EnableErrorUnitInterceptor();
var container = builder.Build();
`
http://johngoldinc.com/Help/html/T_ErrorUnit_Interfaces_IInjector.htm

http://johngoldinc.com