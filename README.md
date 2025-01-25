# Backend Developer Tech Task

## Overview

This project implements a checkout system for a supermarket, where each item is identified by a Stock Keeping Unit (SKU). The system calculates the total price of scanned items, including support for special pricing rules.

---

## Project Structure

The project is organized into three key components:

- **CheckoutProcessor**: Contains the main business logic for the checkout system.
- **CheckoutProcessor.Tests**: Unit tests for validating the functionality and correctness of the `CheckoutProcessor` library.
- **CheckoutConsole**: A simple console application for manually testing the checkout functionality.

---

## Problem Description

In this task:
1. Goods are priced individually.
2. Some items have special offers. For example:
   - SKU `A`: 50 pounds each or 3 for 130.
   - SKU `B`: 30 pounds each or 2 for 45.
   - SKU `C`: 20 pounds.
   - SKU `D`: 15 pounds.

The system should handle:
- Any order of scanned items.
- Dynamic pricing rules that can be updated.

---

## Suggested Interface

```csharp
public interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}
