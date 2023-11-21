# PGTA_AsterixSW
EETAC project

# Objectives
Creation and development of an ASTERIX decoder for category 048 that is capable of exporting the results to a CSV file in the specified format. This exported file will be analyzable later on (for example, the input data for project 3).

Additionally, in the developed software, flight paths can be visualized on a map and simulated over time. These trajectories can also be exported to a KML file.

Furthermore, this project is not just a programming project; it requires an understanding of the meaning of the obtained information and knowledge of how an SSR+Mode S system works.

# Category 048
Provides different data source sets:
- PSR Radar SSR Radar
- M-SSR Radar
- Mode-S Station

# Data Item
For each Data Category there is a Catalogue of Dara Items standarised.
Each Data Item has a unique reference that consists of an 8-character reference Innn/AAA:
- I = Data Item
- nnn = Data Category to which it belongs (000, 255)
- AAA = Decimal number to indicate the data item

Data Items are assigned to a Data Field that have a integral number of octets referenced by a Field Reference Number (FRN)
![image](https://github.com/mariaubiergo2/PGTA_AsterixSW/assets/91792580/9d267759-daa3-49a2-8517-39b7f67cb9ac)

