# -*- coding: utf-8 -*-
"""

@author: mateo
"""

import pandas as pd
import statsmodels.api as sm
from statsmodels.formula.api import ols

df = pd.read_csv('results.csv')

df.columns = df.columns.str.replace(' ', '_')