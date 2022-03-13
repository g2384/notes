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