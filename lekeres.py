from os import system
import csv
system("cls")

file = open("otos.csv")
csvreader = csv.reader(file)

sorok = []
for sor in csvreader:
    sorok.append(sor)

file.close()

# múlt heti sorsolások

multheti_szamok_sor_1 = str(sorok[0]).split(";")
multheti_szamok_sor_2 = str(sorok[1]).split(";")

print(f"Múlt heti nyerőszámok: {multheti_szamok_sor_1[-5:]}")
print(f"Előző heti nyerőszámok: {multheti_szamok_sor_2[-5:]}")

# leggyakoribb számok

egysor = []

for i in range(len(sorok)):
    egysor = str(sorok[i]).split(";")[-5:]

sorted()