@excho off
cls

copy LICENSE .mkdocs\LICENSE.md
copy .github\CONTRIBUTING.md .mkdocs\

mkdocs build
