from random import randint, random
import random
import os

random.seed(0)

for dir in ["ex3data", "ex4data", "ex5data"]:
    if not os.path.exists(dir):
        os.makedirs(dir)

print("Criando arquivos para o Ex. 3...")

a = [random.random() for i in range(10000000)]
b = [random.random() for i in range(10000000)]

with open("ex3data/vetor_a.txt", "w") as file:
    file.writelines((f"{x}\n" for x in a))
with open("ex3data/vetor_b.txt", "w") as file:
    file.writelines((f"{x}\n" for x in b))

print("Criando arquivos para o Ex. 4...")

ints = [randint(0, 2147483647) for i in range(10_000_000)]

with open("ex4data/unsorted_ints.txt", "w") as file:
    file.writelines((f"{x}\n" for x in ints))

# ints.sort()

# with open("ex4data/sorted_ints.txt", "w") as file:
#     file.writelines((f"{x}\n" for x in
#                      ints))


print("Criando arquivos para o Ex. 5...")

num_ids = 100
num_transactions = 10000
funds = {}
with open("ex5data/transactions.txt", "w") as file:
    # generate initial values
    for i in range(num_ids):
        fund = randint(100, 1000)
        funds[i] = fund
        file.write(f"INITIALFUNDS {i} = {fund}\n")
    for i in range(num_transactions):
        a = None
        while True:
            a = randint(0, num_ids-1)
            if funds[a] >= 2:
                break
        b = None
        while True:
            b = randint(0, num_ids-1)
            if b != a:
                break
        transfer_amount = randint(1, funds[a])
        funds[a] -= transfer_amount
        funds[b] += transfer_amount
        file.write(f"TRANSFER {transfer_amount} FROM {a} TO {b}\n")

with open("ex5data/expected_transaction_results.txt", "w") as file:
    for i in range(num_ids):
        file.write(f"FUNDS {i} = {funds[i]}\n")
