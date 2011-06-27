def collatz(numero)
  puts numero

  if numero == 1
    return
  end

  if numero % 2 == 0
    collatz(numero / 2)
  else
    collatz(3 * numero + 1)
  end
end

collatz(50)