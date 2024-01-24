# Git

## Git refuses to reset/discard files

0. make sure:
   - `git config --global core.autocrlf false`
   - you don't have a .gitattributes file with eol directives that would try to convert the end-of-lines.
1. `git rm --cached -r .` (Remove everything from the index.)
2. `git reset --hard` (Write both the index and working directory from git's database.)

## `warning: current Git remote contains credentials`

This is from git-lfs. Because origin url contains access token, e.g. https://abc:<AccesToken>@dev.azure.com/abc/def/_git/def
   
Solution:
1. do not use git-lfs
2. use
   - `git -c http.extraheader="AUTHORIZATION: bearer $accessToken" fetch`;
   - and `git -c http.https://abc@dev.azure.com.extraheader="AUTHORIZATION: bearer $accessToken" lfs fetch`;

## do not use git tags
Why?
1. tags can be deleted/added/renamed at any time against any commit;
2. fetching git tags will cancel out the effect of sparse-checkout;

```ps1
# Proof: run git sparse checkout with this command which fetches all tags:
git fetch -j 4 --tags --prune --prune-tags --progress --no-recurse-submodules --depth 1 origin feature/test
               ^^^^^^
# output:
# remote: Azure Repos
# remote: Found 100000 objects to send. (n ms)
# Receiving objects:   n% (n/100000), n MiB | n MiB/s

# Remove the --tags option:
git fetch -j 4 --prune --prune-tags --progress --no-recurse-submodules --depth 1 origin feature/test

# output:
# remote: Azure Repos
# remote: Found 55000 objects to send. (n ms)
# Receiving objects:   n% (n/55000), n MiB | n MiB/s
```

## `git clean -ffdx`

Remove all extra folders and files in this repo + submodules

This gets you in same state as fresh clone.

source: https://stackoverflow.com/a/42185640

why double `f`?

> Git will refuse to modify untracked nested git repositories (directories with a .git subdirectory) unless a second -f is given. (https://git-scm.com/docs/git-clean)

## blame a deleted line

> git log -S <string> path/to/file

e.g.

> git log -S "var a = 0;" UnitTest.cs
