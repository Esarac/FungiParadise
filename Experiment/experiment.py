# -*- coding: utf-8 -*-
"""

@author: mateo
"""

import pandas as pd
import statsmodels.api as sm
from statsmodels.formula.api import ols

df = pd.read_csv('results.csv')

df.columns = df.columns.str.replace(' ', '_')

dt_value_counts = df['Decision_Tree'].value_counts()

variables = 'Accuracy ~ C(Decision_Tree)'

model = ols(variables, df).fit()

table = sm.stats.anova_lm(model, typ=2)

print(table.to_string())