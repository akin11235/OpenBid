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

Great question! Here's where you are and what happens next:

## Current State:

- ✅ Your changes are committed **locally** on `feature/search-service` branch
- ❌ They're **not on GitHub/remote** yet (not pushed)
- ❌ They're **not on `main`** branch yet

## What Happens Next - Typical Workflow:

**1. Push your feature branch to remote:**

```powershell
git push origin feature/search-service
```

This creates the branch on GitHub and uploads your commit.

**2. Create a Pull Request (PR) on GitHub:**

- Go to your repo on GitHub
- Click "Compare & pull request"
- Review your changes
- Request review from teammates (if applicable)
- Merge when ready

**3. Merge to main (two options):**

**Option A: Via GitHub PR (recommended)**

- Click "Merge Pull Request" on GitHub
- Delete the feature branch after merging

**Option B: Locally**

```powershell
git checkout main
git merge feature/search-service
git push origin main
git branch -d feature/search-service  # Delete local branch
```

## Right Now, You Can:

- Keep working on the feature branch and make more commits
- Push when you're ready to share/backup
- Switch to `main` anytime (your commit is safe on the feature branch)

**Want to continue developing the search service?** Stay on the feature branch and keep committing. **Want to work on something else?** Switch to `main` - your search service changes stay isolated on the feature branch.

What do you want to do next?

Great question! Let's explore this:

## What Happens with Multiple Unpushed Commits?

```powershell
# You make multiple commits locally
git commit -m "Add search service scaffold"
git commit -m "Add MongoDB configuration"
git commit -m "Implement search endpoint"
git commit -m "Add unit tests"

# Then push once
git push origin feature/search-service
```

**Result:** All 4 commits are pushed to GitHub at once, preserving the complete history.

## Best Practices:

### ✅ **Commit Often Locally**

- Commit after each logical unit of work
- Small, focused commits with clear messages
- Example: "Add user validation", "Fix null reference bug", "Update README"

### ✅ **Push Regularly (But Not Every Commit)**

Good times to push:

- End of work day (backup your work)
- After completing a feature/task
- Before switching to another machine
- When you want feedback/code review
- Every few hours for active development

### ❌ **Don't Wait Too Long to Push**

Problems with waiting:

- Risk losing work if your machine crashes
- Harder for teammates to see your progress
- Merge conflicts pile up
- No backup if something goes wrong

## Common Workflows:

**Solo Developer:**

```powershell
# Work for 1-2 hours, make 3-5 commits
git commit -m "..."
git commit -m "..."
git commit -m "..."

# Push at logical break point
git push origin feature/search-service
```

**Team Environment:**

```powershell
# Push more frequently - at least daily
git push origin feature/search-service  # End of day
```

## Advanced: Cleaning Up History Before Push

If you made messy commits locally, you can clean them up before pushing:

```powershell
# Squash last 4 commits into 1
git rebase -i HEAD~4

# Or amend the last commit
git commit --amend -m "Better commit message"
```

⚠️ **WARNING:** Only do this on commits you **haven't pushed yet**. Never rewrite history that's already on GitHub.

## My Recommendation:

1. **Commit locally** every time you complete a small task (10-30 minutes of work)
2. **Push** every 2-3 hours or when you're done for the day
3. **Create PR** when feature is complete and ready for review

This balances:

- ✅ Good commit history
- ✅ Regular backups
- ✅ Team visibility
- ✅ Flexibility to refine work before sharing

**For your search service:** Make commits as you add features, push at the end of each coding session or when you want to create a PR.
