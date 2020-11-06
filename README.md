# etimo-cli

## Create package

To create a nupkg with the tool, issue the following command:

```
dotnet build
```

This will build both the `etimo.cli` nuget and the `etimo.cli.tool` tool in the `./nupkg` folder.

## Install tool

After completing the build step above, run the following:

```
dotnet tool install --global --add-source ./nupkg etimo.cli.tool
```

This will install the tool globally so you can use it from anywhere:

```
etimo --help
```

### Uninstall tool

To uninstall the tool, simply run:

```
dotnet tool uninstall --global etimo.cli.tool
```
