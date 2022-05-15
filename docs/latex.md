# Latex

## `article`

```tex
\documentclass{article}
\usepackage{geometry}
\geometry{
    a4paper,
    total={170mm,257mm},
    left=20mm,
    top=20mm,
}
\thispagestyle{plain}
\begin{document}
\begin{center}
    \Large
    \textbf{Centred Title}
\end{center}
\vspace{0.3cm}
\begin{flushleft}
    Left aligned...
\end{flushleft}
\end{document}
```

## Section

```tex
\usepackage{titlesec}
%...
\titleformat*{\section}{\normalsize\bfseries} % from \usepackage{titlesec}
\titleformat{\subsection}[block]
    {\small\bfseries}
    {\relax}{0pt}
    {}
%...
\begin{flushleft}
    \section{Title 1}
        ...
    \section{Title 2}
        ...
    \subsection{a)}
        ...
\end{flushleft}
```

Preview

```
1 Title 1
  ...
2 Title 2
  ...
a)
  ...
```

## Code

```tex
    \begin{verbatim}
var a = 1 + 1;
    \end{verbatim}

% inline:
print this \verb|inline-code|.
```