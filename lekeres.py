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

nyeroszamok = []

for i in range(len(sorok)):
    nyeroszamok.append(str(sorok[i]).split(";")[-5:])

# múlt heti sorsolások

multheti_szamok_sor_1 = str(sorok[0]).split(";")
multheti_szamok_sor_2 = str(sorok[1]).split(";")

print(f"Múlt heti nyerőszámok: {multheti_szamok_sor_1[-5:]}")
print(f"Előző heti nyerőszámok: {multheti_szamok_sor_2[-5:]}")

