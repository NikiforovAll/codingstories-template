# Coding Stories Template

[![GitHub Actions Status](https://github.com/NikiforovAll/codingstories-template/workflows/Build/badge.svg?branch=main)](https://github.com/NikiforovAll/codingstories-template/actions)

[![GitHub Actions Build History](https://buildstats.info/github/chart/Username/Project?branch=main&includeBuildsFromPullRequest=false)](https://github.com/NikiforovAll/codingstories-template/actions)

The goal of this project is to encourage people to create coding stories. Great developer experience encourages people to try coding stories and invest time to become an author.

## Usage

The engine itself `dotnet new` provides information about possible configuration options.

```bash
dotnet new story -h
```

### Usage examples

The next command create default template in `my-awesome-story` folder.

`dotnet new story -n my-awesome-story`

You can use `--dry-run` option to see what happens during command execution.

```bash
$ dotnet new story -n my-awesome-story --dry-run
File actions would have been taken:
  Create: .editorconfig
  Create: .gitattributes
  Create: .gitignore
  Create: my-awesome-story.sln
  Create: README.md
  Create: TODO.html

Processing post-creation actions...
Description:
Manual instructions: Open the TODO.html in a web browser to see a to-do list.
Actual command: powershell.exe start TODO.html
```
