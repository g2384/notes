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

## Read tsv, csv as code

```tex
\usepackage{pgfplotstable, tabularx}
%...
\pgfplotstabletypeset[col sep=tab,
    font=\ttfamily,
    begin table={\begin{tabularx}{\textwidth}},
    end table={\end{tabularx}},
    every column/.style = {verb string type},
    column type=l,
    every head row/.style={before row=\hline},
    every last row/.style={after row=\hline}
]{file.tsv}
```

## Images

### row = 1, column = 2

```tex
\usepackage{graphicx, subcaption, float}
%...
\begin{figure}[H]%
    \centering
    \subfloat[\centering sub caption a here]{\includegraphics[width=0.48\textwidth]{a.png}}
    \quad
    \subfloat[\centering sub caption b here]{\includegraphics[width=0.48\textwidth]{b.png}}
    \caption{A caption here}%
    \label{fig:one_label}%
\end{figure}
```

### Place image immediately after text

```tex
\usepackage{float}
\begin{figure}[H]
    \includegraphics[width=8cm]{a.png}
\end{figure}

\begin{table}[H]
\end{table}
```

## Group

To change `setlength` in a section

```tex
\begingroup
\section{Part A}
\setlength{\parskip}{1em}

...

\endgroup

\section{Part B}
...
```

## def

```tex
% shorter minus sign
\def\-{\text{-}}

% usage
I^{\-1}
```

## footnotes

```tex
Here is a footnote \footnote{a, b, c, \url{https://www.google.com}}.
```