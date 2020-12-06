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
tq_value_counts = df['Train_Quantity'].value_counts()

variables = 'Accuracy ~ C(Decision_Tree) + C(Train_Quantity) + C(Decision_Tree):C(Train_Quantity)'

model = ols(variables, df).fit()

table = sm.stats.anova_lm(model, typ=2)

print(table.to_string())
print('')
print(df.groupby(['Decision_Tree', 'Train_Quantity'], as_index=False).mean())