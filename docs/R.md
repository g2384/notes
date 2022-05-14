# R

## Basic

```r
library(tidyverse)

# read csv
dat <- read.csv(file = "dat.csv", sep = ",", header = T)

# copy to new column
dat$name2 <- dat$name1

# produce a coloured scatter plot
ggplot(dat, aes(x, y)) + 
  geom_point(aes(colour = cat))

# convert type to boolean factor
dat$a_type <- as.factor(as.numeric(dat$type == "a"))

# calculate sum of d for each type
aggregate(dat$d, list(dat$type), FUN=sum)

# sample output:
#   Group.1      x
# 1       a 6766.7
# 2       b 8193.5
# 3       c 2650.5
```