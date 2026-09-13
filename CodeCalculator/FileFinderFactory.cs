using CodeCalculator.FileFinders;
using System.Text;

namespace CodeCalculator;

internal static class FileFinderFactory
{
    private sealed record ProjectType(
        string Name,
        string Description,
        Func<IFileFinder> Factory);

    private static readonly IReadOnlyDictionary<int, ProjectType> ProjectTypes =
        new Dictionary<int, ProjectType>
        {
            [1] = new("C#", "C# and .NET projects", () => new CsFileFinder()),
            [2] = new("JavaScript", "JavaScript projects", () => new JavaScriptFileFinder()),
            [3] = new("TypeScript", "TypeScript projects", () => new TypeScriptFileFinder()),
            [4] = new("Python", "Python projects", () => new PythonFileFinder()),
            [5] = new("Java / Kotlin", "Java and Kotlin projects", () => new JavaKotlinFileFinder()),
            [6] = new("C / C++", "C and C++ projects", () => new CppFileFinder()),
            [7] = new("Go", "Go projects", () => new GoFileFinder()),
            [8] = new("Rust", "Rust projects", () => new RustFileFinder()),

            [9] = new("PHP", "PHP projects", () => new PhpFileFinder()),
            [10] = new("Ruby", "Ruby projects", () => new RubyFileFinder()),
            [11] = new("Swift", "Swift and Apple platform projects", () => new SwiftFileFinder()),
            [12] = new("Dart", "Dart projects", () => new DartFileFinder()),
            [13] = new("Scala", "Scala projects", () => new ScalaFileFinder()),
            [14] = new("F#", "F# projects", () => new FSharpFileFinder()),
            [15] = new("Visual Basic", "Visual Basic projects", () => new VisualBasicFileFinder()),
            [16] = new("R", "R projects", () => new RFileFinder()),

            [17] = new("Lua", "Lua projects", () => new LuaFileFinder()),
            [18] = new("Julia", "Julia projects", () => new JuliaFileFinder()),
            [19] = new("Objective-C", "Objective-C projects", () => new ObjectiveCFileFinder()),
            [20] = new("Fortran", "Fortran projects", () => new FortranFileFinder()),
            [21] = new("Pascal", "Pascal projects", () => new PascalFileFinder()),
            [22] = new("Haskell", "Haskell projects", () => new HaskellFileFinder()),
            [23] = new("Elixir", "Elixir projects", () => new ElixirFileFinder()),
            [24] = new("Erlang", "Erlang projects", () => new ErlangFileFinder()),

            [25] = new("Clojure", "Clojure projects", () => new ClojureFileFinder()),
            [26] = new("Groovy", "Groovy projects", () => new GroovyFileFinder()),
            [27] = new("OCaml", "OCaml projects", () => new OCamlFileFinder()),
            [28] = new("Crystal", "Crystal projects", () => new CrystalFileFinder()),
            [29] = new("Zig", "Zig projects", () => new ZigFileFinder()),
            [30] = new("Nim", "Nim projects", () => new NimFileFinder()),

            [31] = new("React", "React projects", () => new ReactFileFinder()),
            [32] = new("Next.js", "Next.js projects", () => new NextJsFileFinder()),
            [33] = new("Vue", "Vue projects", () => new VueFileFinder()),
            [34] = new("Angular", "Angular projects", () => new AngularFileFinder()),
            [35] = new("Node.js", "Node.js projects", () => new NodeJsFileFinder()),
            [36] = new("React Native", "React Native projects", () => new ReactNativeFileFinder()),
            [37] = new("Flutter", "Flutter projects", () => new FlutterFileFinder()),
            [38] = new("Ionic", "Ionic projects", () => new IonicFileFinder()),

            [39] = new("SolidJS", "SolidJS projects", () => new SolidFileFinder()),
            [40] = new("Remix", "Remix projects", () => new RemixFileFinder()),
            [41] = new("Gatsby", "Gatsby projects", () => new GatsbyFileFinder()),
            [42] = new("Astro / Nuxt", "Astro and Nuxt projects", () => new AstroNuxtFileFinder()),
            [43] = new("Vite", "Vite projects", () => new ViteFileFinder()),
            [44] = new("NestJS", "NestJS projects", () => new NestJsFileFinder()),
            [45] = new("Electron", "Electron projects", () => new ElectronFileFinder()),

            [46] = new("Unity", "Unity projects", () => new UnityFileFinder()),
            [47] = new("Unreal Engine", "Unreal Engine projects", () => new UnrealFileFinder()),
            [48] = new("Godot", "Godot projects", () => new GodotFileFinder()),
            [49] = new("Android", "Android projects", () => new AndroidFileFinder()),
            [50] = new("MATLAB", "MATLAB projects", () => new MATLABFileFinder()),

            [51] = new("SQL", "SQL and database projects", () => new SqlFileFinder()),
            [52] = new("GraphQL", "GraphQL projects", () => new GraphQLFileFinder()),
            [53] = new("Docker", "Docker projects", () => new DockerFileFinder()),
            [54] = new("Kubernetes", "Kubernetes projects", () => new KubernetesFileFinder()),
            [55] = new("Helm", "Helm projects", () => new HelmFileFinder()),
            [56] = new("Terraform", "Terraform projects", () => new TerraformFileFinder()),
            [57] = new("Ansible", "Ansible projects", () => new AnsibleFileFinder()),

            [58] = new("GitHub Actions", "GitHub Actions workflows", () => new GitHubActionsFileFinder()),
            [59] = new("Azure Pipelines", "Azure Pipelines configurations", () => new AzurePipelinesFileFinder()),
            [60] = new("Vagrant", "Vagrant projects", () => new VagrantFileFinder()),
            [61] = new("Nix", "Nix projects", () => new NixFileFinder()),
            [62] = new("CMake", "CMake projects", () => new CMakeFileFinder()),
            [63] = new("Make", "Make-based projects", () => new MakeFileFinder()),
            [64] = new("Bazel", "Bazel projects", () => new BazelFileFinder()),

            [65] = new("Meson", "Meson projects", () => new MesonFileFinder()),
            [66] = new("Static Site", "Static website projects", () => new StaticSiteFileFinder()),
            [67] = new("OpenAPI", "OpenAPI projects and specifications", () => new OpenApiFileFinder()),
            [68] = new("Protocol Buffers", "Protocol Buffers projects", () => new ProtocolBuffersFileFinder()),
            [69] = new("Kubernetes Manifest", "Kubernetes manifest files", () => new KubernetesManifestFileFinder()),
            [70] = new("Generic Text", "Generic text-based projects", () => new GenericTextFileFinder())
        };

    public static IFileFinder Create(int projectType)
    {
        if (!ProjectTypes.TryGetValue(projectType, out ProjectType? type))
        {
            throw new ArgumentOutOfRangeException(
                nameof(projectType),
                projectType,
                "Unknown project type.");
        }

        return type.Factory();
    }

    public static string GetGuide(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(n);

        int x = n * 8;
        int start = x - 7;

        var builder = new StringBuilder();
        builder.AppendLine("Project Types:");
        builder.AppendLine();

        for (int i = start; i <= x; i++)
        {
            if (!ProjectTypes.TryGetValue(i, out ProjectType? type))
                continue;

            builder.AppendLine($"{i}. {type.Name} — {type.Description}");
        }

        return builder.ToString().TrimEnd();
    }
}