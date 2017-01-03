## Install Via Visual Studio

In the *Extensions and Updates* dialog in Visual Studio, search for 'luminous',
then select and install the *Luminous Code* package that you need.

## Install Via Visual Studio Marketplace

In the *Visual Studio Marketplace* website, search for 'luminous',
then select and install the *Luminous Code* package that you need.

---

## Core Project

`Luminous.Code.Core` is a plain C# class library project that serves as a recepticle
that holds the lower level classes, methods and extension methods that get used by the more 
specialised projects that that use it as a dependency.

`Luminous.Code.Core` contains several namespaces:

* `Luminous.Code.StringExtensions`
* `Luminous.Code.???`

Note the lack of `Core` in the namespace names. It was my decision that there was no benefit
to extending the length of namespaces that sometimes makes the namespaces sound a bit odd.

---

## VisualStudio Project

`Luminous.Code.VisualStudio` is also just a plain C# class library project,
that has a project reference to the `Luminous.Code.Core` project,
as it uses some of the code found in it.

`Luminous.Code.VisualStudio` contains several namespaces:

* `Luminous.Code.VisualStudio.Packages`
* `Luminous.Code.VisualStudio.Commands`
* `Luminous.Code.VisualStudio.TeamExplorer`

### VisualStudio.Packages <small>(namespace)</small>

The `Luminous.Code.VisualStudio.Packages` namespace contains all of the plumbing code that
a Visual Studio package needs to interact with the Visual Studio IDE.

### VisualStudio.Packages.LuminousPackage <small>(class)</small>

The `LuminousPackage` class is an abstract base class that you inherit your own
packages from.  It abstracts away the packages and command interact with the Visual Studio IDE.

##  

### VisualStudio.Commands <small>(namespace)</small>

The `Luminous.Code.VisualStudio.Commands` namespace contains all of the plumbing code that
a command needs to interact with the Visual Studio IDE (via the command's parent `Package`.

### VisualStudio.Packages.LuminousCommand <small>(class)</small>

`LuminousCommand` is an abstract class, which acts as the
common base class for the `StaticCommand` class and the `DynamicCommand` class.
It contains all of the plumbing code that a command needs to interact easily with
its parent package, which has the ability to communicates with the IDE.

### VisualStudio.Packages.StaticCommand <small>(class)</small>

`StaticCommand` is useful for commands whose text doesn't need to change,
and which are always visible and always enabled.

### VisualStudio.Packages.DynamicCommand <small>(class)</small>

`DynamicCommand` is used for commands whose *text* may need to change, and which may
need to dynamically determine if the command needs to be *visible* or *enabled*. 
Three sensibly-named overridable properties are provided to make this easy and flexible.

#### CanExecute <small>(property)</small>

If this property returns `false`, the command cannot be executed at all.
The command's `Visible` and `Enabled`properties will also be set to `false`.

For example, command classes that inherit from `DynamicCommand` can override this
property to return, say, a package-wide value that can be set in *Tools* | *Options*,
or use some other method of determining if the command's functionality should be turned
off.

#### IsActive (property)

If this property returns `false`, the command's `Enabled` is also set to false.
A common use for this property is to be able to check some complicated *context*  that
can't be set in the package's *VSCT* file.

#### Text (property)

