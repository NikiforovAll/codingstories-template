# Coding Stories Template

[![GitHub Actions Status](https://github.com/NikiforovAll/codingstories-template/workflows/Build/badge.svg?branch=main)](https://github.com/NikiforovAll/codingstories-template/actions)

[![GitHub Actions Build History](https://buildstats.info/github/chart/nikiforovall/codingstories-template?branch=main&includeBuildsFromPullRequest=false)](https://github.com/NikiforovAll/codingstories-template/actions)

The goal of this project is to encourage people to create coding stories. Great developer experience encourages people to try coding stories and invest time to become an author.

## Overview

The engine itself `dotnet new` provides information about possible configuration options.

```bash
dotnet new story -h
```

### Usage

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

### Usage - Java

`dotnet new story-java -n my-awesome-story`

## Run in Docker

You can use [coding-stories-scaffolder](https://github.com/users/NikiforovAll/packages/container/package/coding-stories-scaffolder) to create tempaltes.
If you don't want to install dotnet SDK you can run the following command:

```bash
docker run -it -v $PWD:/out --rm ghcr.io/nikiforovall/coding-stories-scaffolder story-java --no-open-todo -n my-awesome-story
```

```bash
# Here is the output of the command above:
$ tree ./my-awesome-story/
./my-awesome-story/
├── pom.xml
├── README.md
└── src
    ├── main
    │   └── java
    │       └── com
    │           └── epam
    │               └── engx
    │                   └── my-awesome-story
    │                       └── foo
    │                           └── Foo.java
    └── test
        └── java
            └── com
                └── epam
                    └── engx
                        └── my-awesome-story
                            └── FooTest.java
```

### Build Docker image locally

`docker build -t ghcr.io/nikiforovall/coding-stories-scaffolder . --build-arg PERSONAL_ACCESS_TOKEN=<PAT>`

### Install template locally

`dotnet nuget add source https://nuget.pkg.github.com/nikiforovall/index.json -n github -u nikiforovall -p <PERSONAL_ACCESS_TOKEN> --store-password-in-clear-text`

`dotnet new --nuget-source https://nuget.pkg.github.com/nikiforovall/index.json --install Epam.CodingStories.Template::*`

## Development

Run build pipeline: `dotnet cake`

## Release

The release of coding-stories-scaffolder docker image is manual and requires `PERSONAL_ACCESS_TOKEN` with corresponding claims.

`docker push ghcr.io/nikiforovall/coding-stories-scaffolder`
