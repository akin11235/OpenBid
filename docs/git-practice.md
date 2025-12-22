Great! Let's practice stashing. Here's how to use it:

## Stash Your Changes

```powershell
# Save your staged changes to the stash
git stash push -m "WIP: search service scaffold"
```

The `-m` flag adds a message so you remember what you stashed.

## Switch to Main

```powershell
git checkout main
```

Your `search-service` folder will disappear! Don't worry, it's safely stashed.

## View Your Stashes

```powershell
# List all stashes
git stash list
```

You'll see something like:

```
stash@{0}: On feature/search-service: WIP: search service scaffold
```

## Go Back and Restore Your Changes

```powershell
# Switch back to feature branch
git checkout feature/search-service

# Restore your changes (removes from stash)
git stash pop

# OR keep a copy in stash
git stash apply
```

## Other Useful Stash Commands

```powershell
# View what's in a stash without applying it
git stash show

# Delete a specific stash
git stash drop stash@{0}

# Delete all stashes
git stash clear
```

**Try it now!** Stash your changes, switch to main, look around, then come back and pop your stash. It's a safe way to learn since your changes are never lost unless you explicitly delete them.
