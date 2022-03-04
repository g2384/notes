# Git

## Git refuses to reset/discard files

0. make sure:
   - `git config --global core.autocrlf false`
   - you don't have a .gitattributes file with eol directives that would try to convert the end-of-lines.
1. `git rm --cached -r .` (Remove everything from the index.)
2. `git reset --hard` (Write both the index and working directory from git's database.)
