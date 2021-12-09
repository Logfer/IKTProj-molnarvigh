from os import system
import csv
import statistics
from statistics import mode
system("cls")

# fájl beolvasása

file = open("otos.csv")
csvreader = csv.reader(file)

sorok = []
for sor in csvreader:
    sorok.append(sor)
file.close()

# lista feltöltése a nyerőszámokkal

nyeroszamok1 = []
nyeroszamok2 = []
nyeroszamok3 = []
nyeroszamok4 = []

for i in range(len(sorok)):
    nyeroszamok1.append(str(sorok[i]).split(";")[-5:])

for j in range(len(nyeroszamok1)):
    target = {39:None, 91:None , 93:None}
    nyeroszamok2.append((str(nyeroszamok1[j]).translate(target)))

for k in range(len(nyeroszamok2)):
    nyeroszamok3.append(nyeroszamok2[k].replace('"', ""))
    print(nyeroszamok3[k])
"""
for k in range(len(nyeroszamok2)):
    nyeroszamok3.append(nyeroszamok2[k].replace('"', ""))
    print(nyeroszamok3[k])
"""
for i in range(len(nyeroszamok3)):
    nyeroszamok3[i] = int(nyeroszamok3[i])
"""
target = {39:None, 91:None , 93:None}
a=(str(nyeroszamok).translate(target))
print("After removing brackets:",a)
"""

# múlt heti sorsolások

multheti_szamok_sor_1 = str(sorok[0]).split(";")
multheti_szamok_sor_2 = str(sorok[1]).split(";")

print(f"Múlt heti nyerőszámok: {multheti_szamok_sor_1[-5:]}")
print(f"Előző heti nyerőszámok: {multheti_szamok_sor_2[-5:]}")

ossz = []

for i in range(len(nyeroszamok3)):
    ossz.append(sum(nyeroszamok3[i]))
    print(ossz[i])