using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Reflection;

namespace CSharpLearning
{
    public class ReflectionAndComposition : IDemonstrate
    {
        public void Demonstrate()
        {
            UseAbstractTypeAsMetadata();
        }
        //306
        public void CheckType()
        {
            Assembly ass = Assembly.LoadFrom("CSharpLearning.dll");
            Type[] types = ass.GetTypes();
            foreach (var t in types)
            {
                Console.WriteLine("{0} -", t.FullName);
                if (t.IsClass)
                    Console.WriteLine("Reference type:");
                else if (t.IsValueType)
                    Console.WriteLine("figure type:");
                else
                    Console.WriteLine("other type");
                Console.WriteLine("\n");
            }
        }
        //307
        public void MyGetMembers()
        {
            Type targetType = typeof(string);
            MemberInfo[] members = targetType.GetMembers(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Public);
            foreach (var info in members)
            {
                Console.WriteLine($"{info.MemberType,-15} : {info.Name}");
            }
        }
        //308
        public class SampleForReflection
        {
            public double ChangeRate(uint af, float xf)
            {
                return default(double);
            }
        }
        public void GetParameters()
        {
            Type tp = typeof(Sample);
            MethodInfo info = tp.GetMethod(nameof(SampleForReflection.ChangeRate));
            if (info != null)
            {
                ParameterInfo[] prms = info.GetParameters();
                Console.WriteLine($"{info.Name} : {prms.Length}");
                foreach (var pi in prms)
                {
                    Console.WriteLine($"{pi.Name} : {pi.ParameterType}");
                }
            }
        }
        //309
        public void GetConstructors()
        {
            Type t = typeof(Samples.Pen);
            ConstructorInfo constructor = t.GetConstructor(Type.EmptyTypes);
            if (constructor != null)
            {
                object instance = constructor.Invoke(null);
                PropertyInfo prop = t.GetProperty("StrokeWidth");
                object val = prop.GetValue(instance);
                Console.WriteLine("StrokeWidth:{0}", val);
            }
        }
        //310
        public void GetStaticMethod()
        {
            MethodInfo addMthd = typeof(ReflectionAndComposition).GetMethod("Add", BindingFlags.Public | BindingFlags.Static);
            if (addMthd != null)
            {
                object[] prms = { 3.65d, 17.073d };
                object returnVal = addMthd.Invoke(null, prms);
                Console.WriteLine("Result:{0}", returnVal);
            }
        }
        public static double Add(double a, double b) => a + b;
        //311
        public class Person
        {
            public Person(string name, string city, int age)
            {
                Name = name;
                City = city;
                Age = age;
            }
            public string Name { get; }
            public string City { get; }
            public int Age { get; }
        }
        public void CreateInstanceByActivator()
        {
            Type t = typeof(Person);
            object instance = Activator.CreateInstance(t, "Mee Yang", "Zhong Shan", 21);
            PropertyInfo[] props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var p in props)
            {
                Console.WriteLine($"{p.Name} : {p.GetValue(instance)}");
            }
        }
        //312
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public sealed class AliasNameAttribute : Attribute
        {
            public AliasNameAttribute(string aliasName)
            {
                Alias = aliasName;
            }
            public string Alias { get; } = null;
        }
        [AliasName("order_data")]
        public class CoreData
        {
        }
        public void CheckCustomAttribute()
        {
            Type t = typeof(CoreData);
            AliasNameAttribute attr = t.GetCustomAttribute<AliasNameAttribute>();
            if (attr != null)
            {
                Console.WriteLine($"type:{t.Name} - Alias:{attr.Alias}");
            }
        }
        //313
        // Get System.Composition by NuGet
        //314
        public interface Transportation
        {
            public string Identity { get; }
        }
        [Export]
        public class Car : Transportation
        {
            public string Identity => "Car";
        }
        [Export]
        public class Bike : Transportation
        {
            public string Identity => "Bike";

        }
        public void GetExportType()
        {
            ContainerConfiguration config = new ContainerConfiguration();
            config.WithAssembly(Assembly.GetExecutingAssembly());
            using (CompositionHost host = config.CreateContainer())
            {
                Transportation c = host.GetExport<Car>();
                Transportation b = host.GetExport<Bike>();
                Console.WriteLine($"c.Identity : {c.Identity}\nb.Indentity : {b.Identity}");
            }
        }
        //315
        public interface IPlayer
        {
            void PlayTracks();
        }
        [Export("gen_pl", typeof(IPlayer))]
        public class GenPlayer : IPlayer
        {
            public void PlayTracks()
            {
                Console.WriteLine("Playing music on an ordinary player...");
            }
        }
        [Export("pro_pl", typeof(IPlayer))]
        public class ProPlayer : IPlayer
        {
            public void PlayTracks()
            {
                Console.WriteLine("Playing music on a professional player...");
            }
        }
        public void BindExportType()
        {
            Assembly currAss = Assembly.GetExecutingAssembly();
            ContainerConfiguration config = new ContainerConfiguration().WithAssembly(currAss);
            using (CompositionHost host = config.CreateContainer())
            {
                IPlayer p1 = host.GetExport<IPlayer>("gen_pl");
                IPlayer p2 = host.GetExport<IPlayer>("pro_pl");
                p1.PlayTracks();
                p2.PlayTracks();
            }

        }
        //316
        public interface IAnimal
        {
            string Name { get; }
            string Family { get; }
        }
        [Export(typeof(IAnimal))]
        public class FelisCatus : IAnimal
        {
            public string Name => "Meow";

            public string Family => "CatFamily";
        }
        [Export(typeof(IAnimal))]
        public class SolenopsisInvictaBuren : IAnimal
        {
            public string Name => "Ant";

            public string Family => "AntFamily";
        }
        [Export(typeof(IAnimal))]
        public class HeliconiusMelpomene : IAnimal
        {
            public string Name => "Bufferfly";

            public string Family => "BufferflyFamily";
        }
        class SomeAnimalSamples
        {
            [ImportMany]
            public IEnumerable<IAnimal> AnimalList { get; set; }
        }
        public void ImportManyTypes()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            ContainerConfiguration config = new ContainerConfiguration().WithAssembly(currentAssembly);
            SomeAnimalSamples samples = new SomeAnimalSamples();
            using (CompositionHost container = config.CreateContainer())
            {
                container.SatisfyImports(samples);
            }
            foreach (var an in samples.AnimalList)
            {
                Console.WriteLine($"Name: {an.Name}\nFamily: {an.Family}\n");
            }
        }
        //317
        [Export]
        [ExportMetadata("Ver", "1.0")]
        [ExportMetadata("Publisher", "Mike")]
        public class TestOne
        {
            public void Run()
            {
                Console.WriteLine("Run...");
            }
        }
        [Import]
        Lazy<TestOne, IDictionary<string, object>> ComposObject { get; set; }
        public void ExportMetadata()
        {
            ContainerConfiguration cfg = new ContainerConfiguration().WithAssembly(Assembly.GetExecutingAssembly());
            ReflectionAndComposition r = new ReflectionAndComposition();
            using (CompositionHost container = cfg.CreateContainer())
            {
                container.SatisfyImports(r);
            }
            TestOne t = r.ComposObject.Value;
            t.Run();
            IDictionary<string, object> metas = r.ComposObject.Metadata;
            foreach (var kv in metas)
            {
                Console.WriteLine($"Key:{kv.Key}, value: {kv.Value}");
            }
        }
        //318
        [Export]
        [ExportMetadata("MaxTracks", 15)]
        [ExportMetadata("Skin", "blue")]
        public class FunMusicPlayer
        {
            public void Play() => Console.WriteLine("Playing music...");
        }
        public class ImportMetadata
        {
            public int MaxTracks { get; set; }
            public string Skin { get; set; }
        }
        [Import]
        public Lazy<FunMusicPlayer, ImportMetadata> CurPlayer { get; set; }
        public void ReceiveMetadataByCustomType()
        {
            ContainerConfiguration cfg = new ContainerConfiguration().WithAssembly(Assembly.GetExecutingAssembly());
            ReflectionAndComposition r = new ReflectionAndComposition();
            using (CompositionHost container = cfg.CreateContainer())
            {
                container.SatisfyImports(r);
            }
            ImportMetadata meta = r.CurPlayer.Metadata;
            Console.WriteLine($"{nameof(ImportMetadata.MaxTracks)}:" +
                              $"{meta.MaxTracks}\n{nameof(ImportMetadata.Skin)}:" +
                              $"{meta.Skin}");
        }
        //319
        public interface ITest
        {
            void RunTask();
        }
        [MetadataAttribute]
        public class CustMetadataAttribute : Attribute
        {
            public string Author { get; set; }
            public string Description { get; set; }
            public int Version { get; set; }
            public CustMetadataAttribute(string author, string desc, int ver)
            {
                Author = author;
                Description = desc;
                Version = ver;
            }
        }
        [Export(typeof(ITest))]
        [CustMetadata("Tom", "debug version", 1)]
        public class TestWork_V1 : ITest
        {
            public void RunTask()
            {
                Console.WriteLine("This is version one.");
            }
        }
        [Export(typeof(ITest))]
        [CustMetadata("Jack", "release version", 2)]
        public class TestWork_V2 : ITest
        {
            public void RunTask()
            {
                Console.WriteLine("This is version two.");
            }
        }
        public class TestCompos
        {
            [ImportMany]
            public IEnumerable<Lazy<ITest, IDictionary<string, object>>> ImportedCompoents { get; set; }
        }
        public void EncapsulateMetadata()
        {
            ContainerConfiguration cfg = new ContainerConfiguration().WithAssembly(Assembly.GetExecutingAssembly());
            ReflectionAndComposition r = new ReflectionAndComposition();
            TestCompos cps = new TestCompos();
            using (var host = cfg.CreateContainer())
            {
                host.SatisfyImports(cps);
            }
            foreach (var c in cps.ImportedCompoents)
            {
                ITest obj = c.Value;
                IDictionary<string, object> meta = c.Metadata;
                Console.WriteLine("Meta:");
                foreach (var it in meta)
                {
                    Console.WriteLine($"  {it.Key}: {it.Value}");
                }
                Console.WriteLine($"call {obj.GetType().Name}\n");
                obj.RunTask();
                Console.WriteLine("----------------------------------\n");
            }
        }
        //320
        public abstract class GenBase
        {
            public abstract Guid ID { get; }
            public abstract string Title { get; }
            public abstract void ConnectEndpoint();
        }
        [Export(typeof(GenBase))]
        public class CompoFirst : GenBase
        {
            public override Guid ID => Guid.NewGuid();
            public override string Title => "test component I";
            public override void ConnectEndpoint()
            {
                Console.WriteLine("Connecting to DWO DB...");
            }
        }
        [Export(typeof(GenBase))]
        public class CompoSecond : GenBase
        {
            public override Guid ID => Guid.NewGuid();
            public override string Title => "test component II";
            public override void ConnectEndpoint()
            {
                Console.WriteLine("Connecting to RLS DB...");
            }
        }
        public void UseAbstractTypeAsMetadata()
        {
            Assembly curAssembly = Assembly.GetExecutingAssembly();
            ContainerConfiguration config = new ContainerConfiguration();
            config.WithAssembly(curAssembly);
            using (var host = config.CreateContainer())
            {
                IEnumerable<GenBase> objs = host.GetExports<GenBase>();
                foreach (var o in objs)
                {
                    Console.WriteLine("ID : {0}\nTitle : {1}\n", o.ID, o.Title);
                    Console.WriteLine("{0} {1}", o.GetType().Name, nameof(GenBase.ConnectEndpoint));
                    o.ConnectEndpoint();
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
