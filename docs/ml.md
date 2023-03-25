## Degrees of freedom

- is often employed to summarize the number of values used in the calculation of a statistic, such as a sample statistic or in a statistical hypothesis test.
- Degrees of freedom generally represents the number of points of control of a system.
- Mathematically, the degrees of freedom is often represented using the Greek letter nu. It may also be abbreviated as “d.o.f,” “dof,” “d.f.,” or simply “df.”
### statistics:
- In statistics, degrees of freedom is the number of observations used to calculate a statistic.
- degrees of freedom = number of independent values – number of statistics
- For example, we may have 50 independent samples and we wish to calculate a statistic of the sample, like the mean. All 50 samples are used in the calculation and there is one statistic, so the number of degrees of freedom for the mean, in this case, is calculated as:
  - degrees of freedom = number of independent values – number of statistics
  - degrees of freedom = 50 – 1
  - degrees of freedom = 49
### ML:
#### for a Linear Regression Model
- In machine learning, the degrees of freedom may refer to **the number of parameters in the model**, such as the number of coefficients in a linear regression model or the number of weights in a deep learning neural network.
- more degrees of freedom (model parameters -> overfitting -> overcome = use regularization techniques
- For example, a model with two parameters (beta1, beta2).
  - yhat = x1 * beta1 + x2 * beta2
- This linear regression model has two degrees of freedom because there are two parameters in the model that must be estimated from a training dataset.
#### for Linear Regression Error
- For example, a model are fit using a training dataset with 100 rows or examples. The total error of the model has one degree of freedom for each example in the training dataset minus the number of parameters estimated from the data.
- In this case, the model error has 100 minus 2 parameters from the model, or 98 degrees of freedom.
  - model error degrees of freedom = number of observations – number of parameters
  - model error degrees of freedom = 100 – 2
  - model error degrees of freedom = 98
#### Total Degrees of Freedom for Linear Regression
- linear regression degrees of freedom = model degrees of freedom + model error degrees of freedom
- linear regression degrees of freedom = 2 + 98
- linear regression degrees of freedom = 100
#### Negative Degrees of Freedom
- more columns than rows of data (we have more statistics than we have values that can change)
#### and overfitting
- in deep models, the effective degrees of freedom may be decoupled from the number of parameters in the model. (Degrees of Freedom in Deep Neural Networks https://arxiv.org/abs/1603.09260, 2016.)
- there is a growing trend by statisticians and machine learning practitioners to move away from degrees of freedom for both a proxy for model complexity and as an expectation for overfitting. (Effective Degrees Of Freedom: A Flawed Metaphor https://arxiv.org/abs/1312.7851, 2013.)

## Handbook of Data Visualization (2008)
### II.6 High-dimensional Data Visualization
- Data visualization can roughly be categorized into two applications: Exploration, Presentation
- Interactive linked highlighting, as described by Wills (2008, Chapter II.9 same volume), is one of the keys to the right use of graphics for high-dimensional data. Linking across different graphs can increase the dimensionality beyond the number of dimensions captured in a single multivariate graphic. Thus, the analyst can choose the most appropriate graphics for certain variables of the data set; linking will preserve the multivariate context.
- Mosaic Plots
  - the multivariate plots that require the most training for a data analyst.
  - extremely versatile when all possible interaction and
variations are employed
  - Several recommendations can be given for the construction of high-dimensional classical mosaicplots:
  - The first two and the last two variables in a mosaicplot can be investigated most efficiently regarding their association. Thus the interaction of interest should be put into the last two positions of the plot. Variables that condition an effect should be the first in the plot.
  - To avoid unnecessary clutter in a mosaicplot of equally important variables, put variables with only a few categories first.
  - If combinations of cells are empty (this is quite common for high-dimensional data due to the curse of dimensionality), seek variables that create empty cells at high levels in the plot to reduce the number of cells to be plotted (empty cells at a higher level are not divided any further, thus gathering many potential cells into one).
  - If the last variable in the plot is a binary factor, one can reduce the number of cells by linking the last variable via highlighting. This is the usual way to handle categorical response models.
  - Subsets of variables may reveal features far more clearly than using all variables at once. In interactive mosaicplots one can add/drop or change variables displayed in a plot. This is very efficient when looking for potential  interactions between variables.
- Trellis Displays
  - use conditioning to plot high-dimensional data (similar to mosaicplots)). But whereas mosaicplots use a recursive layout, trellis displays use a gridlike structure to plot the data conditioned on certain subgroups.
  - example: boxplot y by x
  - In principle, a single trellis display can hold up to seven variables at a time. Naturally five out of the seven variables need to be categorical, and two can be continuous.
  - **axis variables**: up to two variables plotted in the panel plot.
  - **conditioning variables**: Up to three categorical variables, to form rows, columns, and pages of the trellis display.
  - **adjunct variables**: The two remaining variables can be coded using different glyphs and colors (if the panel plot is a glyph-based plot).
- Trellis displays and mosaicplots do not have very much in common.
- Parallel Coordinate Plots
  - escape the dimensionality of two or three dimensions and can accommodate many variables at a time by plotting the coordinate axes in parallel.
  - Geometrical Aspects vs. Data Analysis Aspects:
    - overview, profiles, monitor
  - Detecting features in parallel coordinates that are **not** visible in a 1-D or 2-D plot is **rare**.
  - useful for interpreting the findings of multivariate procedures like outlier detection, clustering, or classification in a highly multivariate context.
  - limits: overplotting (a few hundreds of lines); solution: use opacity
  - Sorting and Scaling Issues
    - Parallel coordinate plots are especially useful for variables which either have an order such as time or all share a common scale
    - Sorting in parallel coordinate plots is crucial for the interpretation of the plots, as interesting patterns are usually revealed at neighboring variables.
    - Scaling: The most important scaling option is to either individually scale the axes or to use a common scale over all axes. Other scaling options define the alignment of the values, which can be aligned at:
      - The mean
      - The median
      - A specific case
      - A specific value
- Projection Pursuit and the Grand Tour
  - grand tour: A continuous 1-parameter family of d-dimensional projections of p-dimensional data that is dense in the set of all d-dimensional projections in R^p. The parameter is usually thought of as time.
### II.7 Multivariate Data Glyphs: Principles and Practice
-  a glyph is a visual representation of a piece of data where the attributes of a graphical entity are dictated by one or more attributes
of a data record.
- Glyphs are one class of visualization techniques used for multivariate data. Their major **strength**, as compared to techniques such as parallel coordinates, scatterplot matrices, and stacked univariate plots, **is that patterns involving more than two or three data dimensions can often be more readily perceived.**
- Subsets of dimensions can form composite visual features that analysts can be trained to detect and classify, leading to a richer description of **interrecord** and **intrarecord** relationships than can be extracted using other techniques.
- Limitations:
  - They are generally restricted in terms of how accurately they can convey data due to their size and the limits of our visual perception system to measure different graphical attributes.
  - There are also constraints on the number of data records that can be effectively visualized with glyphs; excessive data set size can result in significant occlusion or the need to reduce the size of each glyph.
- **Multivariate data**, also called multidimensional or n-dimensional data, consist of some number of items or records, n, each of which is defined by a d-vector of values.
-  can be viewed as a dxn matrix, where each row represents a **data record** and each column represents an **observation**, **variable**, or **dimension**.
- Variables/dimensions can be independent or dependent, which might imply that some ordering or grouping of dimensions could be beneficial.
- graphical attributes to which data values can be mapped: position (1-, 2-, or 3-D), size (length, area, or volume), shape, orientation, material (hue, saturation, intensity, texture, or opacity), line style (width, dashes, or tapers), and dynamics (speed of motion, direction of motion, rate of flashing).
- biases:
  - Perception-based bias
  - Proximity-based bias
  - Grouping-based bias
- Ordering of Data Dimensions/Variables:
  - Correlation-driven
  - Symmetry-driven
  - Data-driven
    - good for time-series data sets to show the evolution of dimensions and their relationships over time.
  - User-driven
- Glyph Layout Options:
  - Data-driven Placement
    - always result in some overlap between glyphs. Random jitter is commonly added to positions in plotting, especially for data that take on only a small number of possible values.
  - Structure-driven Placement
    -  A common type of structure is an ordering relationship, such as in time-series or spatial data.
    - hierarchical or tree-based structures.
- Evaluation:
  - Evaluation based on ranking of human perceptual abilities for different graphical attributes;
  - Evaluation based on the speed and accuracy of users performing specific tasks;
  - Evaluation based on ease of detection of data features in the presence of occlusion and clutter
  - Evaluation based on the scalability of techniques in terms of number of records and dimensions.

# Dimensionality reduction:

The proposed dimensionality reduction approaches can be categorised by a number of factors including
whether they are:
- linear or non-linear approaches
- supervised or unsupervised approaches
- suitable for continuous, categorical variables, a combination of the two types of data or dissimilarity
data

## Principal components analysis (PCA)

It is a **linear** dimensionality reduction approach that finds orthogonal projections of the original (usually) high dimensional data onto a lower dimensional linear space. It is an **unsupervised** method as it does not make any use of the sample labels, even if they exist.

### PCA is widely used for:

- **visualisation purposes** reduce the original data into a two or three-dimensional space. (2, 3 PCAs)
- **feature extraction** where the number of projections are selected based on the objective, e.g. minimising the mean squared error in a regression problem.

Usually the first PCs provide a good reconstruction of the data into a lower dimensional space, a space that explains that a large proportion of the overall **variance** of the data.